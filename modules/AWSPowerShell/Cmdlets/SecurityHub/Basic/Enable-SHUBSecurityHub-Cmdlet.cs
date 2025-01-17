/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Enables Security Hub for your account in the current Region or the Region you specify
    /// in the request.
    /// 
    ///  
    /// <para>
    /// When you enable Security Hub, you grant to Security Hub the permissions necessary
    /// to gather findings from other services that are integrated with Security Hub.
    /// </para><para>
    /// When you use the <code>EnableSecurityHub</code> operation to enable Security Hub,
    /// you also automatically enable the following standards.
    /// </para><ul><li><para>
    /// CIS Amazon Web Services Foundations
    /// </para></li><li><para>
    /// Amazon Web Services Foundational Security Best Practices
    /// </para></li></ul><para>
    /// You do not enable the Payment Card Industry Data Security Standard (PCI DSS) standard.
    /// 
    /// </para><para>
    /// To not enable the automatically enabled standards, set <code>EnableDefaultStandards</code>
    /// to <code>false</code>.
    /// </para><para>
    /// After you enable Security Hub, to enable a standard, use the <code>BatchEnableStandards</code>
    /// operation. To disable a standard, use the <code>BatchDisableStandards</code> operation.
    /// </para><para>
    /// To learn more, see the <a href="https://docs.aws.amazon.com/securityhub/latest/userguide/securityhub-settingup.html">setup
    /// information</a> in the <i>Security Hub User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "SHUBSecurityHub", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub EnableSecurityHub API operation.", Operation = new[] {"EnableSecurityHub"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.EnableSecurityHubResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.EnableSecurityHubResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.EnableSecurityHubResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableSHUBSecurityHubCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        #region Parameter EnableDefaultStandard
        /// <summary>
        /// <para>
        /// <para>Whether to enable the security standards that Security Hub has designated as automatically
        /// enabled. If you do not provide a value for <code>EnableDefaultStandards</code>, it
        /// is set to <code>true</code>. To not enable the automatically enabled standards, set
        /// <code>EnableDefaultStandards</code> to <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableDefaultStandards")]
        public System.Boolean? EnableDefaultStandard { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the hub resource when you enable Security Hub.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.EnableSecurityHubResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-SHUBSecurityHub (EnableSecurityHub)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.EnableSecurityHubResponse, EnableSHUBSecurityHubCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnableDefaultStandard = this.EnableDefaultStandard;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SecurityHub.Model.EnableSecurityHubRequest();
            
            if (cmdletContext.EnableDefaultStandard != null)
            {
                request.EnableDefaultStandards = cmdletContext.EnableDefaultStandard.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SecurityHub.Model.EnableSecurityHubResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.EnableSecurityHubRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "EnableSecurityHub");
            try
            {
                #if DESKTOP
                return client.EnableSecurityHub(request);
                #elif CORECLR
                return client.EnableSecurityHubAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Boolean? EnableDefaultStandard { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SecurityHub.Model.EnableSecurityHubResponse, EnableSHUBSecurityHubCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

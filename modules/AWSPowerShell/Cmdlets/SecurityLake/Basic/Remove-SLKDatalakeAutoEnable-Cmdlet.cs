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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Automatically deletes Amazon Security Lake to stop collecting security data. When
    /// you delete Amazon Security Lake from your account, Security Lake is disabled in all
    /// Regions. Also, this API automatically takes steps to remove the account from Security
    /// Lake . 
    /// 
    ///  
    /// <para>
    /// This operation disables security data collection from sources, deletes data stored,
    /// and stops making data accessible to subscribers. Security Lake also deletes all the
    /// existing settings and resources that it stores or maintains for your Amazon Web Services
    /// account in the current Region, including security log and event data. The <code>DeleteDatalake</code>
    /// operation does not delete the Amazon S3 bucket, which is owned by your Amazon Web
    /// Services account. For more information, see the <a href="https://docs.aws.amazon.com/security-lake/latest/userguide/disable-security-lake.html">Amazon
    /// Security Lake User Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SLKDatalakeAutoEnable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Security Lake DeleteDatalakeAutoEnable API operation.", Operation = new[] {"DeleteDatalakeAutoEnable"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSLKDatalakeAutoEnableCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        #region Parameter RemoveFromConfigurationForNewAccount
        /// <summary>
        /// <para>
        /// <para>Delete Amazon Security Lake with the specified configuration settings to stop ingesting
        /// security data for new accounts in Security Lake. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RemoveFromConfigurationForNewAccounts")]
        public Amazon.SecurityLake.Model.AutoEnableNewRegionConfiguration[] RemoveFromConfigurationForNewAccount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RemoveFromConfigurationForNewAccount), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SLKDatalakeAutoEnable (DeleteDatalakeAutoEnable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableResponse, RemoveSLKDatalakeAutoEnableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.RemoveFromConfigurationForNewAccount != null)
            {
                context.RemoveFromConfigurationForNewAccount = new List<Amazon.SecurityLake.Model.AutoEnableNewRegionConfiguration>(this.RemoveFromConfigurationForNewAccount);
            }
            #if MODULAR
            if (this.RemoveFromConfigurationForNewAccount == null && ParameterWasBound(nameof(this.RemoveFromConfigurationForNewAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter RemoveFromConfigurationForNewAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableRequest();
            
            if (cmdletContext.RemoveFromConfigurationForNewAccount != null)
            {
                request.RemoveFromConfigurationForNewAccounts = cmdletContext.RemoveFromConfigurationForNewAccount;
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
        
        private Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "DeleteDatalakeAutoEnable");
            try
            {
                #if DESKTOP
                return client.DeleteDatalakeAutoEnable(request);
                #elif CORECLR
                return client.DeleteDatalakeAutoEnableAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityLake.Model.AutoEnableNewRegionConfiguration> RemoveFromConfigurationForNewAccount { get; set; }
            public System.Func<Amazon.SecurityLake.Model.DeleteDatalakeAutoEnableResponse, RemoveSLKDatalakeAutoEnableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

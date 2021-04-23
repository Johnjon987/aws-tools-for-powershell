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
using Amazon.NimbleStudio;
using Amazon.NimbleStudio.Model;

namespace Amazon.PowerShell.Cmdlets.NS
{
    /// <summary>
    /// Update a Studio resource.
    /// 
    ///  
    /// <para>
    /// Currently, this operation only supports updating the displayName of your studio.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "NSStudio", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NimbleStudio.Model.Studio")]
    [AWSCmdlet("Calls the Amazon Nimble Studio UpdateStudio API operation.", Operation = new[] {"UpdateStudio"}, SelectReturnType = typeof(Amazon.NimbleStudio.Model.UpdateStudioResponse))]
    [AWSCmdletOutput("Amazon.NimbleStudio.Model.Studio or Amazon.NimbleStudio.Model.UpdateStudioResponse",
        "This cmdlet returns an Amazon.NimbleStudio.Model.Studio object.",
        "The service call response (type Amazon.NimbleStudio.Model.UpdateStudioResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateNSStudioCmdlet : AmazonNimbleStudioClientCmdlet, IExecutor
    {
        
        #region Parameter AdminRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that Studio Admins will assume when logging in to the Nimble Studio portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminRoleArn { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A friendly name for the studio.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter StudioId
        /// <summary>
        /// <para>
        /// <para>The studio ID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String StudioId { get; set; }
        #endregion
        
        #region Parameter UserRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that Studio Users will assume when logging in to the Nimble Studio portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserRoleArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>To make an idempotent API request using one of these actions, specify a client token
        /// in the request. You should not reuse the same client token for other API requests.
        /// If you retry a request that completed successfully using the same client token and
        /// the same parameters, the retry succeeds without performing any further actions. If
        /// you retry a successful request using the same client token, but one or more of the
        /// parameters are different, the retry fails with a ValidationException error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Studio'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NimbleStudio.Model.UpdateStudioResponse).
        /// Specifying the name of a property of type Amazon.NimbleStudio.Model.UpdateStudioResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Studio";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StudioId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StudioId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StudioId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StudioId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NSStudio (UpdateStudio)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NimbleStudio.Model.UpdateStudioResponse, UpdateNSStudioCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StudioId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdminRoleArn = this.AdminRoleArn;
            context.ClientToken = this.ClientToken;
            context.DisplayName = this.DisplayName;
            context.StudioId = this.StudioId;
            #if MODULAR
            if (this.StudioId == null && ParameterWasBound(nameof(this.StudioId)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserRoleArn = this.UserRoleArn;
            
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
            var request = new Amazon.NimbleStudio.Model.UpdateStudioRequest();
            
            if (cmdletContext.AdminRoleArn != null)
            {
                request.AdminRoleArn = cmdletContext.AdminRoleArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.StudioId != null)
            {
                request.StudioId = cmdletContext.StudioId;
            }
            if (cmdletContext.UserRoleArn != null)
            {
                request.UserRoleArn = cmdletContext.UserRoleArn;
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
        
        private Amazon.NimbleStudio.Model.UpdateStudioResponse CallAWSServiceOperation(IAmazonNimbleStudio client, Amazon.NimbleStudio.Model.UpdateStudioRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nimble Studio", "UpdateStudio");
            try
            {
                #if DESKTOP
                return client.UpdateStudio(request);
                #elif CORECLR
                return client.UpdateStudioAsync(request).GetAwaiter().GetResult();
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
            public System.String AdminRoleArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DisplayName { get; set; }
            public System.String StudioId { get; set; }
            public System.String UserRoleArn { get; set; }
            public System.Func<Amazon.NimbleStudio.Model.UpdateStudioResponse, UpdateNSStudioCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Studio;
        }
        
    }
}

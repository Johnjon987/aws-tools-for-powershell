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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Updates a domain name.
    /// </summary>
    [Cmdlet("Update", "AG2DomainName", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 UpdateDomainName API operation.", Operation = new[] {"UpdateDomainName"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAG2DomainNameCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DomainNameConfiguration
        /// <summary>
        /// <para>
        /// <para>The domain name configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainNameConfigurations")]
        public Amazon.ApiGatewayV2.Model.DomainNameConfiguration[] DomainNameConfiguration { get; set; }
        #endregion
        
        #region Parameter MutualTlsAuthentication_TruststoreUri
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URL that specifies the truststore for mutual TLS authentication, for
        /// example, s3://<replaceable>bucket-name</replaceable>/<replaceable>key-name</replaceable>.
        /// The truststore can contain certificates from public or private certificate authorities.
        /// To update the truststore, upload a new version to S3, and then update your custom
        /// domain name to use the new version. To update the truststore, you must have permissions
        /// to access the S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MutualTlsAuthentication_TruststoreUri { get; set; }
        #endregion
        
        #region Parameter MutualTlsAuthentication_TruststoreVersion
        /// <summary>
        /// <para>
        /// <para>The version of the S3 object that contains your truststore. To specify a version,
        /// you must have versioning enabled for the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MutualTlsAuthentication_TruststoreVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AG2DomainName (UpdateDomainName)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse, UpdateAG2DomainNameCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DomainNameConfiguration != null)
            {
                context.DomainNameConfiguration = new List<Amazon.ApiGatewayV2.Model.DomainNameConfiguration>(this.DomainNameConfiguration);
            }
            context.MutualTlsAuthentication_TruststoreUri = this.MutualTlsAuthentication_TruststoreUri;
            context.MutualTlsAuthentication_TruststoreVersion = this.MutualTlsAuthentication_TruststoreVersion;
            
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
            var request = new Amazon.ApiGatewayV2.Model.UpdateDomainNameRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.DomainNameConfiguration != null)
            {
                request.DomainNameConfigurations = cmdletContext.DomainNameConfiguration;
            }
            
             // populate MutualTlsAuthentication
            var requestMutualTlsAuthenticationIsNull = true;
            request.MutualTlsAuthentication = new Amazon.ApiGatewayV2.Model.MutualTlsAuthenticationInput();
            System.String requestMutualTlsAuthentication_mutualTlsAuthentication_TruststoreUri = null;
            if (cmdletContext.MutualTlsAuthentication_TruststoreUri != null)
            {
                requestMutualTlsAuthentication_mutualTlsAuthentication_TruststoreUri = cmdletContext.MutualTlsAuthentication_TruststoreUri;
            }
            if (requestMutualTlsAuthentication_mutualTlsAuthentication_TruststoreUri != null)
            {
                request.MutualTlsAuthentication.TruststoreUri = requestMutualTlsAuthentication_mutualTlsAuthentication_TruststoreUri;
                requestMutualTlsAuthenticationIsNull = false;
            }
            System.String requestMutualTlsAuthentication_mutualTlsAuthentication_TruststoreVersion = null;
            if (cmdletContext.MutualTlsAuthentication_TruststoreVersion != null)
            {
                requestMutualTlsAuthentication_mutualTlsAuthentication_TruststoreVersion = cmdletContext.MutualTlsAuthentication_TruststoreVersion;
            }
            if (requestMutualTlsAuthentication_mutualTlsAuthentication_TruststoreVersion != null)
            {
                request.MutualTlsAuthentication.TruststoreVersion = requestMutualTlsAuthentication_mutualTlsAuthentication_TruststoreVersion;
                requestMutualTlsAuthenticationIsNull = false;
            }
             // determine if request.MutualTlsAuthentication should be set to null
            if (requestMutualTlsAuthenticationIsNull)
            {
                request.MutualTlsAuthentication = null;
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
        
        private Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.UpdateDomainNameRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "UpdateDomainName");
            try
            {
                #if DESKTOP
                return client.UpdateDomainName(request);
                #elif CORECLR
                return client.UpdateDomainNameAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public List<Amazon.ApiGatewayV2.Model.DomainNameConfiguration> DomainNameConfiguration { get; set; }
            public System.String MutualTlsAuthentication_TruststoreUri { get; set; }
            public System.String MutualTlsAuthentication_TruststoreVersion { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.UpdateDomainNameResponse, UpdateAG2DomainNameCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

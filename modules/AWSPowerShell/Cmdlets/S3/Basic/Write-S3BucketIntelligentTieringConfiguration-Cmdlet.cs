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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Amazon.S3.IAmazonS3.PutBucketIntelligentTieringConfiguration
    /// </summary>
    [Cmdlet("Write", "S3BucketIntelligentTieringConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketIntelligentTieringConfiguration API operation.", Operation = new[] {"PutBucketIntelligentTieringConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketIntelligentTieringConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketIntelligentTieringConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketIntelligentTieringConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3BucketIntelligentTieringConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the Amazon S3 bucket whose configuration you want to modify or retrieve.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter IntelligentTieringFilter_IntelligentTieringFilterPredicate
        /// <summary>
        /// <para>
        /// Filter Predicate setup for specific filter types.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntelligentTieringConfiguration_IntelligentTieringFilter_IntelligentTieringFilterPredicate")]
        public Amazon.S3.Model.IntelligentTieringFilterPredicate IntelligentTieringFilter_IntelligentTieringFilterPredicate { get; set; }
        #endregion
        
        #region Parameter IntelligentTieringId
        /// <summary>
        /// <para>
        /// The ID used to identify the S3 Intelligent-Tiering configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IntelligentTieringId { get; set; }
        #endregion
        
        #region Parameter IntelligentTieringConfiguration_IntelligentTieringId
        /// <summary>
        /// <para>
        /// The ID used to identify the S3 Intelligent-Tiering configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IntelligentTieringConfiguration_IntelligentTieringId { get; set; }
        #endregion
        
        #region Parameter IntelligentTieringConfiguration_Status
        /// <summary>
        /// <para>
        /// Specifies the status of the configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.IntelligentTieringStatus")]
        public Amazon.S3.IntelligentTieringStatus IntelligentTieringConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter IntelligentTieringConfiguration_Tiering
        /// <summary>
        /// <para>
        /// Specifies the S3 Intelligent-Tiering storage class tier of the configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntelligentTieringConfiguration_Tierings")]
        public Amazon.S3.Model.Tiering[] IntelligentTieringConfiguration_Tiering { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketIntelligentTieringConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketIntelligentTieringConfiguration (PutBucketIntelligentTieringConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketIntelligentTieringConfigurationResponse, WriteS3BucketIntelligentTieringConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.IntelligentTieringId = this.IntelligentTieringId;
            context.IntelligentTieringConfiguration_IntelligentTieringId = this.IntelligentTieringConfiguration_IntelligentTieringId;
            context.IntelligentTieringFilter_IntelligentTieringFilterPredicate = this.IntelligentTieringFilter_IntelligentTieringFilterPredicate;
            context.IntelligentTieringConfiguration_Status = this.IntelligentTieringConfiguration_Status;
            if (this.IntelligentTieringConfiguration_Tiering != null)
            {
                context.IntelligentTieringConfiguration_Tiering = new List<Amazon.S3.Model.Tiering>(this.IntelligentTieringConfiguration_Tiering);
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
            var request = new Amazon.S3.Model.PutBucketIntelligentTieringConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.IntelligentTieringId != null)
            {
                request.IntelligentTieringId = cmdletContext.IntelligentTieringId;
            }
            
             // populate IntelligentTieringConfiguration
            var requestIntelligentTieringConfigurationIsNull = true;
            request.IntelligentTieringConfiguration = new Amazon.S3.Model.IntelligentTieringConfiguration();
            System.String requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringId = null;
            if (cmdletContext.IntelligentTieringConfiguration_IntelligentTieringId != null)
            {
                requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringId = cmdletContext.IntelligentTieringConfiguration_IntelligentTieringId;
            }
            if (requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringId != null)
            {
                request.IntelligentTieringConfiguration.IntelligentTieringId = requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringId;
                requestIntelligentTieringConfigurationIsNull = false;
            }
            Amazon.S3.IntelligentTieringStatus requestIntelligentTieringConfiguration_intelligentTieringConfiguration_Status = null;
            if (cmdletContext.IntelligentTieringConfiguration_Status != null)
            {
                requestIntelligentTieringConfiguration_intelligentTieringConfiguration_Status = cmdletContext.IntelligentTieringConfiguration_Status;
            }
            if (requestIntelligentTieringConfiguration_intelligentTieringConfiguration_Status != null)
            {
                request.IntelligentTieringConfiguration.Status = requestIntelligentTieringConfiguration_intelligentTieringConfiguration_Status;
                requestIntelligentTieringConfigurationIsNull = false;
            }
            List<Amazon.S3.Model.Tiering> requestIntelligentTieringConfiguration_intelligentTieringConfiguration_Tiering = null;
            if (cmdletContext.IntelligentTieringConfiguration_Tiering != null)
            {
                requestIntelligentTieringConfiguration_intelligentTieringConfiguration_Tiering = cmdletContext.IntelligentTieringConfiguration_Tiering;
            }
            if (requestIntelligentTieringConfiguration_intelligentTieringConfiguration_Tiering != null)
            {
                request.IntelligentTieringConfiguration.Tierings = requestIntelligentTieringConfiguration_intelligentTieringConfiguration_Tiering;
                requestIntelligentTieringConfigurationIsNull = false;
            }
            Amazon.S3.Model.IntelligentTieringFilter requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter = null;
            
             // populate IntelligentTieringFilter
            var requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilterIsNull = true;
            requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter = new Amazon.S3.Model.IntelligentTieringFilter();
            Amazon.S3.Model.IntelligentTieringFilterPredicate requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter_intelligentTieringFilter_IntelligentTieringFilterPredicate = null;
            if (cmdletContext.IntelligentTieringFilter_IntelligentTieringFilterPredicate != null)
            {
                requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter_intelligentTieringFilter_IntelligentTieringFilterPredicate = cmdletContext.IntelligentTieringFilter_IntelligentTieringFilterPredicate;
            }
            if (requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter_intelligentTieringFilter_IntelligentTieringFilterPredicate != null)
            {
                requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter.IntelligentTieringFilterPredicate = requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter_intelligentTieringFilter_IntelligentTieringFilterPredicate;
                requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilterIsNull = false;
            }
             // determine if requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter should be set to null
            if (requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilterIsNull)
            {
                requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter = null;
            }
            if (requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter != null)
            {
                request.IntelligentTieringConfiguration.IntelligentTieringFilter = requestIntelligentTieringConfiguration_intelligentTieringConfiguration_IntelligentTieringFilter;
                requestIntelligentTieringConfigurationIsNull = false;
            }
             // determine if request.IntelligentTieringConfiguration should be set to null
            if (requestIntelligentTieringConfigurationIsNull)
            {
                request.IntelligentTieringConfiguration = null;
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
        
        private Amazon.S3.Model.PutBucketIntelligentTieringConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketIntelligentTieringConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketIntelligentTieringConfiguration");
            try
            {
                #if DESKTOP
                return client.PutBucketIntelligentTieringConfiguration(request);
                #elif CORECLR
                return client.PutBucketIntelligentTieringConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public System.String IntelligentTieringId { get; set; }
            public System.String IntelligentTieringConfiguration_IntelligentTieringId { get; set; }
            public Amazon.S3.Model.IntelligentTieringFilterPredicate IntelligentTieringFilter_IntelligentTieringFilterPredicate { get; set; }
            public Amazon.S3.IntelligentTieringStatus IntelligentTieringConfiguration_Status { get; set; }
            public List<Amazon.S3.Model.Tiering> IntelligentTieringConfiguration_Tiering { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketIntelligentTieringConfigurationResponse, WriteS3BucketIntelligentTieringConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Creates a tracker resource in your AWS account, which lets you retrieve current and
    /// historical location of devices.
    /// </summary>
    [Cmdlet("New", "LOCTracker", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.CreateTrackerResponse")]
    [AWSCmdlet("Calls the Amazon Location Service CreateTracker API operation.", Operation = new[] {"CreateTracker"}, SelectReturnType = typeof(Amazon.LocationService.Model.CreateTrackerResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.CreateTrackerResponse",
        "This cmdlet returns an Amazon.LocationService.Model.CreateTrackerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLOCTrackerCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the tracker resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>A key identifier for an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-keys.html">AWS
        /// KMS customer managed key</a>. Enter a key ID, key ARN, alias name, or alias ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PricingPlan
        /// <summary>
        /// <para>
        /// <para>Specifies the pricing plan for the tracker resource.</para><para>For additional details and restrictions on each pricing plan option, see the <a href="https://aws.amazon.com/location/pricing/">Amazon
        /// Location Service pricing page</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LocationService.PricingPlan")]
        public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
        #endregion
        
        #region Parameter PricingPlanDataSource
        /// <summary>
        /// <para>
        /// <para>Specifies the data provider for the tracker resource.</para><ul><li><para>Required value for the following pricing plans: <code>MobileAssetTracking </code>|
        /// <code>MobileAssetManagement</code></para></li></ul><para>For more information about <a href="https://aws.amazon.com/location/data-providers/">Data
        /// Providers</a>, and <a href="https://aws.amazon.com/location/pricing/">Pricing plans</a>,
        /// see the Amazon Location Service product page.</para><note><para>Amazon Location Service only uses <code>PricingPlanDataSource</code> to calculate
        /// billing for your tracker resource. Your data will not be shared with the data provider,
        /// and will remain in your AWS account or Region unless you move it.</para></note><para>Valid Values: <code>Esri</code> | <code>Here</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PricingPlanDataSource { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Applies one or more tags to the tracker resource. A tag is a key-value pair helps
        /// manage, identify, search, and filter your resources by labelling them.</para><para>Format: <code>"key" : "value"</code></para><para>Restrictions:</para><ul><li><para>Maximum 50 tags per resource</para></li><li><para>Each resource tag must be unique with a maximum of one value.</para></li><li><para>Maximum key length: 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length: 256 Unicode characters in UTF-8</para></li><li><para>Can use alphanumeric characters (A–Z, a–z, 0–9), and the following characters: + -
        /// = . _ : / @. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TrackerName
        /// <summary>
        /// <para>
        /// <para>The name for the tracker resource.</para><para>Requirements:</para><ul><li><para>Contain only alphanumeric characters (A-Z, a-z, 0-9) , hyphens (-), periods (.), and
        /// underscores (_).</para></li><li><para>Must be a unique tracker resource name.</para></li><li><para>No spaces allowed. For example, <code>ExampleTracker</code>.</para></li></ul>
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
        public System.String TrackerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.CreateTrackerResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.CreateTrackerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrackerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrackerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrackerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrackerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LOCTracker (CreateTracker)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.CreateTrackerResponse, NewLOCTrackerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrackerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.KmsKeyId = this.KmsKeyId;
            context.PricingPlan = this.PricingPlan;
            #if MODULAR
            if (this.PricingPlan == null && ParameterWasBound(nameof(this.PricingPlan)))
            {
                WriteWarning("You are passing $null as a value for parameter PricingPlan which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PricingPlanDataSource = this.PricingPlanDataSource;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.TrackerName = this.TrackerName;
            #if MODULAR
            if (this.TrackerName == null && ParameterWasBound(nameof(this.TrackerName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.CreateTrackerRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.PricingPlan != null)
            {
                request.PricingPlan = cmdletContext.PricingPlan;
            }
            if (cmdletContext.PricingPlanDataSource != null)
            {
                request.PricingPlanDataSource = cmdletContext.PricingPlanDataSource;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrackerName != null)
            {
                request.TrackerName = cmdletContext.TrackerName;
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
        
        private Amazon.LocationService.Model.CreateTrackerResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.CreateTrackerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "CreateTracker");
            try
            {
                #if DESKTOP
                return client.CreateTracker(request);
                #elif CORECLR
                return client.CreateTrackerAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
            public System.String PricingPlanDataSource { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TrackerName { get; set; }
            public System.Func<Amazon.LocationService.Model.CreateTrackerResponse, NewLOCTrackerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

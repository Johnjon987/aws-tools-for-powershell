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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Updates an existing cost anomaly monitor subscription.
    /// </summary>
    [Cmdlet("Update", "CEAnomalySubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cost Explorer UpdateAnomalySubscription API operation.", Operation = new[] {"UpdateAnomalySubscription"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse))]
    [AWSCmdletOutput("System.String or Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCEAnomalySubscriptionCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter Frequency
        /// <summary>
        /// <para>
        /// <para> The update to the frequency value at which subscribers will receive notifications.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.AnomalySubscriptionFrequency")]
        public Amazon.CostExplorer.AnomalySubscriptionFrequency Frequency { get; set; }
        #endregion
        
        #region Parameter MonitorArnList
        /// <summary>
        /// <para>
        /// <para> A list of cost anomaly subscription ARNs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MonitorArnList { get; set; }
        #endregion
        
        #region Parameter Subscriber
        /// <summary>
        /// <para>
        /// <para> The update to the subscriber list. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subscribers")]
        public Amazon.CostExplorer.Model.Subscriber[] Subscriber { get; set; }
        #endregion
        
        #region Parameter SubscriptionArn
        /// <summary>
        /// <para>
        /// <para> A cost anomaly subscription Amazon Resource Name (ARN). </para>
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
        public System.String SubscriptionArn { get; set; }
        #endregion
        
        #region Parameter SubscriptionName
        /// <summary>
        /// <para>
        /// <para> The subscription's new name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriptionName { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para> The update to the threshold value for receiving notifications. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Threshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SubscriptionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SubscriptionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubscriptionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubscriptionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubscriptionArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CEAnomalySubscription (UpdateAnomalySubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse, UpdateCEAnomalySubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubscriptionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Frequency = this.Frequency;
            if (this.MonitorArnList != null)
            {
                context.MonitorArnList = new List<System.String>(this.MonitorArnList);
            }
            if (this.Subscriber != null)
            {
                context.Subscriber = new List<Amazon.CostExplorer.Model.Subscriber>(this.Subscriber);
            }
            context.SubscriptionArn = this.SubscriptionArn;
            #if MODULAR
            if (this.SubscriptionArn == null && ParameterWasBound(nameof(this.SubscriptionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriptionName = this.SubscriptionName;
            context.Threshold = this.Threshold;
            
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
            var request = new Amazon.CostExplorer.Model.UpdateAnomalySubscriptionRequest();
            
            if (cmdletContext.Frequency != null)
            {
                request.Frequency = cmdletContext.Frequency;
            }
            if (cmdletContext.MonitorArnList != null)
            {
                request.MonitorArnList = cmdletContext.MonitorArnList;
            }
            if (cmdletContext.Subscriber != null)
            {
                request.Subscribers = cmdletContext.Subscriber;
            }
            if (cmdletContext.SubscriptionArn != null)
            {
                request.SubscriptionArn = cmdletContext.SubscriptionArn;
            }
            if (cmdletContext.SubscriptionName != null)
            {
                request.SubscriptionName = cmdletContext.SubscriptionName;
            }
            if (cmdletContext.Threshold != null)
            {
                request.Threshold = cmdletContext.Threshold.Value;
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
        
        private Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.UpdateAnomalySubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "UpdateAnomalySubscription");
            try
            {
                #if DESKTOP
                return client.UpdateAnomalySubscription(request);
                #elif CORECLR
                return client.UpdateAnomalySubscriptionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CostExplorer.AnomalySubscriptionFrequency Frequency { get; set; }
            public List<System.String> MonitorArnList { get; set; }
            public List<Amazon.CostExplorer.Model.Subscriber> Subscriber { get; set; }
            public System.String SubscriptionArn { get; set; }
            public System.String SubscriptionName { get; set; }
            public System.Double? Threshold { get; set; }
            public System.Func<Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse, UpdateCEAnomalySubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SubscriptionArn;
        }
        
    }
}

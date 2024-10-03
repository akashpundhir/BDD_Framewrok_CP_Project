﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ColoplastProfessional.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("1_SignUp")]
    public partial class _1_SignUpFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "1_SignUp.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, NUnit.Framework.TestContext.CurrentContext.WorkerId);
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "1_SignUp", "\tAs a user I want to Sign Up to the Coloplast Professional", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 5
#line hidden
#line 6
 await testRunner.GivenAsync("Edge browser is started", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 7
 await testRunner.AndAsync("Professional site is opened", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 8
 await testRunner.AndAsync("User accepted the cookies", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("SignUp with a new user")]
        [NUnit.Framework.CategoryAttribute("regression")]
        public async System.Threading.Tasks.Task SignUpWithANewUser()
        {
            string[] tagsOfScenario = new string[] {
                    "regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("SignUp with a new user", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 5
await this.FeatureBackgroundAsync();
#line hidden
#line 12
 await testRunner.GivenAsync("User clicks Login", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 13
 await testRunner.AndAsync("User clicks Sign Up now", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 14
 await testRunner.WhenAsync("User fills info", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 15
 await testRunner.AndAsync("User creates new B2C Account", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 16
 await testRunner.ThenAsync("Account is created", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User can reset the password")]
        [NUnit.Framework.CategoryAttribute("regression")]
        public async System.Threading.Tasks.Task UserCanResetThePassword()
        {
            string[] tagsOfScenario = new string[] {
                    "regression"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User can reset the password", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 19
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 5
await this.FeatureBackgroundAsync();
#line hidden
#line 20
 await testRunner.GivenAsync("User clicks Login", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 21
 await testRunner.AndAsync("User clicks Sign Up now", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 22
 await testRunner.WhenAsync("User fills info", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 23
 await testRunner.AndAsync("User creates new B2C Account", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 24
 await testRunner.ThenAsync("Account is created", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 25
 await testRunner.AndAsync("I want browser to be restarted", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 26
 await testRunner.AndAsync("Professional site is opened", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 27
 await testRunner.WhenAsync("User clicks Login", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 28
 await testRunner.AndAsync("I click forgot password", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 29
 await testRunner.ThenAsync("I see reset password flow is started", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 30
 await testRunner.WhenAsync("I write email address", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 31
 await testRunner.AndAsync("Click Send code button", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 32
 await testRunner.AndAsync("I got verification code from email", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 33
 await testRunner.AndAsync("Create a new password", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 34
 await testRunner.AndAsync("I click continue", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 35
 await testRunner.ThenAsync("I successfully logged in", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion

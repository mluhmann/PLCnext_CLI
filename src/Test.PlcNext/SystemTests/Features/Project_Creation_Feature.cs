﻿#region Copyright
///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) Phoenix Contact GmbH & Co KG
//  This software is licensed under Apache-2.0
//
///////////////////////////////////////////////////////////////////////////////
#endregion

using System.Threading.Tasks;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using Test.PlcNext.SystemTests.StepDefinitions;
#pragma warning disable 4014

namespace Test.PlcNext.SystemTests.Features
{
	[FeatureDescription(@"User creates new project via CLI with different parameters.")]
    [Label("ART-PLCNEXT-Toolchains-1585")]
	public class Project_Creation_Feature : MockedSystemTestBase
	{
		[Scenario]
		public async Task Create_new_project_with_specific_name()
		{
            await Runner.AddSteps(
				_ => Given_is_an_empty_workspace(),
				_ => When_I_create_a_new_project_with_name("NewProject"),
				_ => Then_the_project_NAME_was_created("NewProject")).RunAsync();
	    }

	    [Scenario]
	    public async Task Create_new_project_with_default_name()
	    {
	        await Runner.AddSteps(
	            _ => Given_is_an_empty_workspace_with_name("Root"),
	            _ => When_I_create_a_new_project(),
	            _ => Then_the_project_NAME_was_created_inside_root_folder("Root")).RunAsync();
	    }

        [Scenario]
	    public async Task Create_new_project_with_specific_name_in_specific_folder()
	    {
	        await Runner.AddSteps(
	            _ => Given_is_an_empty_workspace(),
	            _ => When_I_create_a_new_project_with_name_in_folder("NewProject", "Fooba"),
	            _ => Then_the_project_NAME_was_created_in_folder("NewProject", "Fooba")).RunAsync();
	    }

	    [Scenario]
	    public async Task Create_new_project_in_existing_folder()
	    {
	        await Runner.AddSteps(
	            _ => Given_is_a_new_project_NAME("NewProject"),
	            _ => When_I_create_a_new_project_with_name("NewProject"),
                _ => Then_the_user_was_informed_that_the_artifact_exists_already()).RunAsync();
	    }

	    [Scenario]
	    public async Task Create_new_project_in_existing_folder_forced()
	    {
	        await Runner.AddSteps(
	            _ => Given_is_a_new_project_NAME("NewProject"),
	            _ => When_I_create_a_new_project_with_name_forced("NewProject"),
	            _ => Then_the_project_NAME_was_again_created("NewProject")).RunAsync();
	    }

        [Scenario]
        public async Task Create_new_project_creates_library_component_and_program()
        {
            await Runner.AddSteps(
                _ => Given_is_an_empty_workspace(),
                _ => When_I_create_a_new_project(),
                _ => Then_the_project_contains_component_and_program_cpp_and_hpp_files()).RunAsync();
        }

        [Scenario]
        public async Task Create_new_project_creates_component_with_specific_name()
        {
            await Runner.AddSteps(
                _ => Given_is_an_empty_workspace(),
                _ => When_I_create_a_new_project_with_componentname("NewComponent"),
                _ => Then_the_project_contains_a_component_with_name("NewComponent")).RunAsync();
        }

        [Scenario]
        public async Task Create_new_project_creates_program_with_specific_name()
        {
            await Runner.AddSteps(
                _ => Given_is_an_empty_workspace(),
                _ => When_I_create_a_new_project_with_programname("NewProgram"),
                _ => Then_the_project_contains_a_program_with_name("NewProgram")).RunAsync();
        }

        [Scenario]
        public async Task Create_new_project_creates_component_and_program_with_correct_namespaces()
        {
            await Runner.AddSteps(
                _ => Given_is_an_empty_workspace(),
                _ => When_I_create_a_new_project_with_name("A.B.C.D"),
                _ => Then_the_components_namespace_starts_with_namespace("DComponent", "A.B.C.D"),
                _ => Then_the_programs_namespace_starts_with_namespace("DProgram", "A.B.C.D")).RunAsync();
        }

        [Scenario]
        public async Task Create_new_app_component_creates_component()
        {
            await Runner.AddSteps(
                _ => Given_is_an_empty_workspace(),
                _ => When_I_create_a_new_appproject_with_componentname("MyProject"),
                _ => Then_the_project_contains_an_appcomponent_with_name("MyProjectComponent")
                ).RunAsync();
        }
	}
}
﻿#region Copyright & License

// Copyright © 2012 - 2020 François Chabot
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using Be.Stateless.BizTalk.ContextProperties;
using FluentAssertions;
using Xunit;

namespace Be.Stateless.BizTalk.Xml.Xsl
{
	public class XslCompiledTransformDescriptorFixture
	{
		[Fact]
		public void DetectsMessageContextRequirement()
		{
			var descriptor = new XslCompiledTransformDescriptor(new XslCompiledTransformDescriptorBuilder(typeof(CompoundContextMapTransform)));
			descriptor.ExtensionRequirements.Should().Be(ExtensionRequirements.MessageContext);
			descriptor.NamespaceResolver.LookupNamespace("bf").Should().Be(BizTalkFactoryProperties.EnvironmentTag.Namespace);
			descriptor.NamespaceResolver.LookupNamespace("bts").Should().Be(BtsProperties.ActualRetryCount.Namespace);
			descriptor.NamespaceResolver.LookupNamespace("tp").Should().BeNull();
		}

		[Fact]
		public void DetectsMessageContextRequirementAbsence()
		{
			var descriptor = new XslCompiledTransformDescriptor(new XslCompiledTransformDescriptorBuilder(typeof(IdentityTransform)));
			descriptor.ExtensionRequirements.Should().Be(ExtensionRequirements.None);
			descriptor.NamespaceResolver.Should().BeNull();
		}

		[Fact]
		[SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
		public void ImplicitlyReliesOnXslMapUrlResolver()
		{
			Action act = () => new XslCompiledTransformDescriptor(new XslCompiledTransformDescriptorBuilder(typeof(CompoundMapTransform)));
			act.Should().NotThrow();
		}
	}
}

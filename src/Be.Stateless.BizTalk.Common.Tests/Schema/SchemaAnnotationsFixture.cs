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

using FluentAssertions;
using Xunit;

namespace Be.Stateless.BizTalk.Schema
{
	public class SchemaAnnotationsFixture
	{
		[Fact]
		public void GetAnnotationByNameIsNotNullForKnownAnnotation()
		{
			SchemaMetadata.For<RootedSchema>().Annotations.GetAnnotation("Properties").Should().NotBeNull();
		}

		[Fact]
		public void GetAnnotationByNameIsNullForUnknownAnnotation()
		{
			SchemaMetadata.For<RootedSchema>().Annotations.GetAnnotation("UnknownAnnotation").Should().BeNull();
		}

		[Fact]
		public void GetAnnotationByNameIsNullWhenAnnotationsAreEmpty()
		{
			SchemaAnnotations.Empty.GetAnnotation("Properties").Should().BeNull();
		}
	}
}

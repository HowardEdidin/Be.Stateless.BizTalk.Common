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
using Be.Stateless.BizTalk.Schema;
using Microsoft.XLANGs.BaseTypes;

namespace Be.Stateless.BizTalk.Runtime.Caching
{
	/// <summary>
	/// Runtime memory cache for the <see cref="ISchemaMetadata"/> associated to <see cref="SchemaBase"/>-derived types.
	/// </summary>
	/// <seealso cref="Cache{TKey,TItem}"/>
	public class SchemaMetadataCache : Cache<Type, ISchemaMetadata>
	{
		/// <summary>
		/// Singleton <see cref="SchemaMetadataCache"/> instance.
		/// </summary>
		public static SchemaMetadataCache Instance { get; } = new SchemaMetadataCache();

		/// <summary>
		/// Create the singleton <see cref="SchemaMetadataCache"/> instance.
		/// </summary>
		private SchemaMetadataCache() { }

		#region Base Class Member Overrides

		protected override string ConvertKeyToString(Type key)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));
			return key.AssemblyQualifiedName;
		}

		protected override ISchemaMetadata CreateItem(Type key)
		{
			return SchemaMetadata.Create(key);
		}

		#endregion
	}
}
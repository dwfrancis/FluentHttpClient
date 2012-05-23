﻿using System;
using System.IO;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Pathoschild.Http.Formatters.Core;

namespace Pathoschild.Http.Formatters.JsonNet
{
	/// <summary>Serializes and deserializes data as BSON.</summary>
	public class JsonNetBsonMediaTypeFormatter : SerializerMediaTypeFormatterBase
	{
		/// <summary>Construct a new instance.</summary>
		public JsonNetBsonMediaTypeFormatter()
		{
			this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/bson"));
		}

		/// <summary>Deserialize an object from the stream.</summary>
		/// <param name="type">The type of object to read.</param>
		/// <param name="stream">The <see cref="Stream"/> from which to read.</param>
		/// <param name="contentHeaders">The <see cref="HttpContentHeaders"/> for the content being read.</param>
		/// <param name="formatterContext">The <see cref="FormatterContext"/> containing the respective request or response.</param>
		/// <returns>Returns a deserialized object.</returns>
		protected override object Deserialize(Type type, Stream stream, HttpContentHeaders contentHeaders, FormatterContext formatterContext)
		{
			JsonSerializer serializer = new JsonSerializer();
			BsonReader reader = new BsonReader(stream);
			return serializer.Deserialize(reader);
		}

		/// <summary>Serialize an object into the stream.</summary>
		/// <param name="type">The type of object to write.</param>
		/// <param name="value">The object instance to write.</param>
		/// <param name="stream">The <see cref="Stream"/> to which to write.</param>
		/// <param name="contentHeaders">The <see cref="HttpContentHeaders"/> for the content being written.</param>
		/// <param name="formatterContext">The <see cref="FormatterContext"/> containing the respective request or response.</param>
		/// <param name="transportContext">The <see cref="TransportContext"/>.</param>
		protected override void Serialize(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, FormatterContext formatterContext, TransportContext transportContext)
		{
			JsonSerializer serializer = new JsonSerializer();
			BsonWriter writer = new BsonWriter(stream);
			serializer.Serialize(writer, value);
		}
	}
}

﻿using System.IO;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Http.PostData {
    
    /// <summary>
    /// Class representing a string HTTP POST value.
    /// </summary>
    public class SocialHttpPostValue : IHttpPostValue {

        #region Properties

        /// <summary>
        /// Gets the name/key of the value.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new HTTP POST value from the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name/key of the value.</param>
        /// <param name="value">The value.</param>
        public SocialHttpPostValue(string name, string value) {
            Name = name;
            Value = value;
        }

        #endregion

        /// <summary>
        /// Writes the value to the specified <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The stream the value should be written to.</param>
        /// <param name="boundary">The multipart boundary.</param>
        /// <param name="newLine">The characters used to indicate a new line.</param>
        /// <param name="isLast">Whether the value is the last in the request body.</param>
        public void WriteToMultipartStream(Stream stream, string boundary, string newLine, bool isLast) {

            SocialHttpPostData.Write(stream, "--" + boundary + newLine);
            SocialHttpPostData.Write(stream, "Content-Disposition: form-data; name=\"" + Name + "\"" + newLine);
            SocialHttpPostData.Write(stream, newLine);

            SocialHttpPostData.Write(stream, Value);

            SocialHttpPostData.Write(stream, newLine);
            SocialHttpPostData.Write(stream, "--" + boundary + (isLast ? "--" : "") + newLine);

        }

        /// <summary>
        /// Gets a string representation of the value.
        /// </summary>
        /// <returns>The value as a string.</returns>
        public override string ToString() {
            return Value;
        }

    }

}
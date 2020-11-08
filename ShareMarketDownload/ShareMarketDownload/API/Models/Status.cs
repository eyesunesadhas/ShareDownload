using System.Collections.Generic;

namespace ShareWatch.DataModel.Common
{
    public class Status
    {
        /// <summary>
        /// Contains Error codes & messages
        /// </summary>
        protected static Dictionary<string, string> m_messageStoreDictionary = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        public Status()
        {
            this.Code = string.Empty;
            this.Description = string.Empty;
            this.RelatedField = string.Empty;
            this.Row = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        /// <param name="code">The error code.</param>
        public Status(string code)
        {
            this.Code = code;
            SetDescriptionMessage(code);
            this.RelatedField = string.Empty;
            this.Row = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="relatedField">The related field.</param>
        public Status(string code, string relatedField)
        {
            this.Code = code;
            SetDescriptionMessage(code);
            this.RelatedField = relatedField;
            this.Row = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="description">The error description.</param>
        /// <param name="row">The error row.</param>
        public Status(string code, string description, int row)
        {
            this.Code = code;
            this.Description = description;
            this.RelatedField = string.Empty;
            this.Row = row;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="description">The description.</param>
        /// <param name="relatedField">The related field.</param>
        /// <param name="row">The row.</param>
        public Status(string code, string description, string relatedField, int row)
        {
            this.Code = code;
            this.Description = description;
            this.RelatedField = relatedField;
            this.Row = row;
        }

        /// <summary>
        /// Gets or sets the Error code.
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the related field.
        /// </summary>
        public string RelatedField
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the row containing error.
        /// </summary>
        public int Row
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the description based on error code.
        /// </summary>
        /// <param name="code">The error code.</param>
        public void SetDescriptionMessage(string code)
        {
            this.Description = string.Empty;

            // Checks whether the dictionary already contains Code
            if (m_messageStoreDictionary != null && m_messageStoreDictionary.ContainsKey(code))
            {
                this.Description = m_messageStoreDictionary[code];
            }
        }
    }
}

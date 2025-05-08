namespace SIS.Domain.Exceptions.Common
{
    /// <summary>
    /// Represents an exception that is thrown when field validation fails.
    /// </summary>
    public class FieldValidationFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValidationFailedException"/> class with a default message.
        /// </summary>
        public FieldValidationFailedException() : base("Field validation failed.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValidationFailedException"/> class with a specified entity name.
        /// </summary>
        /// <param name="entity">The name of the entity for which validation failed.</param>
        public FieldValidationFailedException(string entity) : base($"Field validation failed for entity: {entity}.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValidationFailedException"/> class with a specified entity name and field name.
        /// </summary>
        /// <param name="entity">The name of the entity for which validation failed.</param>
        /// <param name="field">The name of the field that failed validation.</param>
        public FieldValidationFailedException(string entity, string field) : base($"Field validation failed for entity: {entity}, field: {field}.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValidationFailedException"/> class with a specified entity name, field name, and a reference to the inner exception.
        /// </summary>
        /// <param name="entity">The name of the entity for which validation failed.</param>
        /// <param name="field">The name of the field that failed validation.</param>
        /// <param name="ex">The exception that is the cause of the current exception.</param>
        public FieldValidationFailedException(string entity, string field, Exception ex) : base($"Field validation failed for entity: {entity}, field: {field}.", ex)
        {
        }
    }
}

namespace SIS.Domain.Exceptions.Common
{
    public class FieldValidationFailedException: Exception
    {
        public FieldValidationFailedException() : base("Field validation failed.")
        {
        }

        public FieldValidationFailedException(string entity) : base($"Field validation failed for entity: {entity}.")
        {
        }

        public FieldValidationFailedException(string entity, string field) : base($"Field validation failed for entity: {entity}, field: {field}.")
        {
        }

        public FieldValidationFailedException(string entity, string field, Exception ex) : base($"Field validation failed for entity: {entity}, field: {field}.", ex)
        {
        }
    }
}

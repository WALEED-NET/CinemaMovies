namespace Cinema_Hope.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSizeInBytes)
        {
            _maxFileSize = maxFileSizeInBytes;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile ;

            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"only Maximum allowed size is {_maxFileSize} bytes.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

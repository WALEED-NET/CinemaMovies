namespace Cinema_Hope.Attributes
{
    public class AlowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string _AlowedExtension;

        public AlowedExtensionsAttribute(string alowedExtension)
        {
            _AlowedExtension = alowedExtension;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                // get file extension .
                var fileExtension = Path.GetExtension(file.FileName);

                //  and check if it alowed. compare 
                bool isAlowed = _AlowedExtension.Split(',').Contains(fileExtension , StringComparer.OrdinalIgnoreCase);

                if (!isAlowed)
                {
                    return new ValidationResult($"only {_AlowedExtension} are Allowed! .");
                }
            }

            return ValidationResult.Success;
        }
    }
}

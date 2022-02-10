using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Extensions
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Maksymalny rozmiar zdjęcia to { _maxFileSize} bajtów.";
        }
    }
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage(extension));
                }
            }

            return ValidationResult.Success;
        }
        public string GetErrorMessage(string extension)
        {
            return $"Zdjęcie nie może mieć rozszerzenia {extension}!";
        }
    }

    public class MaxWidthHeightAttribute : ValidationAttribute
    {
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        public MaxWidthHeightAttribute(int maxWidth, int maxHeight)
        {
            _maxWidth = maxWidth;
            _maxHeight = maxHeight;
        }
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                using (var image = Image.FromStream(file.OpenReadStream()))
                {
                    if (image.Width > _maxWidth || image.Height > _maxHeight)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return $"Zdjęcie może mieć maksymalnie {_maxWidth} px szerokości i {_maxHeight} px wysokości!";
        }
    }

    public class MinWidthHeightAttribute : ValidationAttribute
    {
        private readonly int _minWidth;
        private readonly int _minHeight;

        public MinWidthHeightAttribute(int minWidth, int minHeight)
        {
            _minWidth = minWidth;
            _minHeight = minHeight;
        }
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                using (var image = Image.FromStream(file.OpenReadStream()))
                {
                    if (image.Width < _minWidth || image.Height < _minHeight)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return $"Zdjęcie musi mieć wymiary minimum {_minWidth} px szerokości i {_minHeight} px wysokości!";
        }
    }

    public class IsSquareAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                using (var image = Image.FromStream(file.OpenReadStream()))
                {
                    if (image.Width != image.Height)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return $"Zdjęcie musi być kwadratem o wymiarach minimum 300x300 pikseli.";
        }
    }
}

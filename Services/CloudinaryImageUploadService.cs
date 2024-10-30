using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using PharmacySystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services
{
    public class CloudinaryImageUploadService : IImageUploadService
    {
        private readonly string cloud = "pharmacydev";
        private readonly string apiKey = "134868154528456";
        private readonly string apiSecret = "kgTFt8V9orUXxFJciwSq3bKhif4";

        private readonly Cloudinary _cloudinary;

        public CloudinaryImageUploadService()
        {
            var account = new Account(cloud, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);

            _cloudinary.Api.Secure = true;

        }

        public async Task<string> UploadImageAsync(string imagePath)
        {
            try
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imagePath)
                };
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult?.SecureUrl?.AbsoluteUri;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error uploading image to Cloudinary", ex);
            }
        }
    }
}

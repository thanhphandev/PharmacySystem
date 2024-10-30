using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services.Interface
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(string imagePath);
    }
}

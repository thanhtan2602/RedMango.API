using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;

namespace RedMango.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageGeneratorController : ControllerBase
    {
        [HttpPost]
        public IActionResult GenerateImage([FromForm] string inputText, [FromForm] IFormFile backgroundImage)
        {
            try
            {
                // Đường dẫn đến thư mục lưu trữ hình ảnh
                string imageDirectory = "path/to/image/directory";

                // Tạo tên duy nhất cho tệp hình ảnh
                string uniqueImageName = Guid.NewGuid().ToString() + ".jpg";

                // Đường dẫn đến tệp hình ảnh kết quả
                string imagePath = Path.Combine(imageDirectory, uniqueImageName);

                // Đọc hình ảnh nền
                using (var backgroundImageStream = backgroundImage.OpenReadStream())
                using (var background = new Bitmap(backgroundImageStream))
                using (var graphics = Graphics.FromImage(background))
                {
                    Font font = new Font(FontFamily.GenericSansSerif, 24);
                    SolidBrush brush = new SolidBrush(Color.Black);
                    Point textPosition = new Point(50, 50);

                    graphics.DrawString(inputText, font, brush, textPosition);

                    // Lưu hình ảnh kết quả
                    background.Save(imagePath, ImageFormat.Jpeg);
                }

                // Trả về đường dẫn hình ảnh kết quả cho frontend
                string imageUrl = "path/to/image/directory/" + uniqueImageName;
                return Ok(new { imageUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}

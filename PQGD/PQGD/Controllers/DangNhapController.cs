using Microsoft.AspNetCore.Mvc;
using PQGD.Data;
using PQGD.Models;

namespace PQGD.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly data_context _context;

        public DangNhapController(data_context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(GiaoVien model)
        {
            // Kiểm tra thông tin đăng nhập và xác thực người dùng
            if (IsValidLogin(model.takhoan, model.matkhau, out var giaoVien))
            {
                // Lưu thông tin người dùng vào session hoặc cookie để giữ phiên đăng nhập

                // Ví dụ: Lưu thông tin người dùng vào session
                HttpContext.Session.SetString("UserId", giaoVien.id_giaovien.ToString());
                HttpContext.Session.SetString("Username", giaoVien.takhoan);

                // Chuyển hướng tới trang chính
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                return View(model);
            }
        }

        private bool IsValidLogin(string username, string password, out GiaoVien giaoVien)
        {
            giaoVien = _context.GiaoViens.FirstOrDefault(gv => gv.takhoan == username && gv.matkhau == password);

            if (giaoVien != null)
            {
                // Xác thực thành công
                return true;
            }
            else
            {
                // Xác thực không thành công
                return false;
            }
        }
    }
}

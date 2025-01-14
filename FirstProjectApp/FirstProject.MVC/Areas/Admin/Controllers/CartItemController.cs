using FirstProject.BL.DTOs.CartItemDtos;
using FirstProject.BL.Services.Abstractions;
using FirstProject.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class CartItemController : Controller
{
    private readonly ICartItemService _cartItemService;

    public CartItemController(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }

    public async Task<IActionResult> Index()
    {

        try
        {
            ICollection<CartItemGetDto> cartItems = await _cartItemService.GetAllCartItemsAsync();
            return View(cartItems);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    public async Task<IActionResult> Detail(int id)
    {
        try
        {
            CartItemGetDetailDto cartItem = await _cartItemService.GetByIdCartItemAsync(id);
            return View(cartItem);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    public async Task<IActionResult> SoftDelete(int id)
    {
        try
        {
            await _cartItemService.SoftDeleteCartItemAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Restore(int id)
    {
        try
        {
            await _cartItemService.RestoreCartItemAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _cartItemService.DeleteCartItemAsync(id);
            return RedirectToAction("Index");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    public IActionResult Trash()
    {
        try
        {
            ICollection<CartItemGetDto> cartItems = _cartItemService.GetAllCartItemsWhichIsSoftDeleted();
            return View(cartItems);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

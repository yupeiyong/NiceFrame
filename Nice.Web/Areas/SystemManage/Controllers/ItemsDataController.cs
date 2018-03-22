using System.Collections.Generic;
using System.Web.Mvc;
using Nice.Common.Json;
using Nice.Domain.Entity.SystemManage;
using Nice.Service.SystemManage;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Areas.SystemManage.Controllers
{
    public class ItemsDataController : Nice.WebPc.Handler.ControllerBase
    {
        private ItemsDetailService _itemsDetailService = new ItemsDetailService();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string itemId, string keyword)
        {
            var data = _itemsDetailService.GetList(itemId, keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectJson(string enCode)
        {
            var data = _itemsDetailService.GetItemList(enCode);
            List<object> list = new List<object>();
            foreach (ItemsDetailBaseEntity item in data)
            {
                list.Add(new { id = item.F_ItemCode, text = item.F_ItemName });
            }
            return Content(list.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _itemsDetailService.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ItemsDetailBaseEntity itemsDetailBaseEntity, string keyValue)
        {
            _itemsDetailService.SubmitForm(itemsDetailBaseEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _itemsDetailService.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}

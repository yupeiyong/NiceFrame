using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Nice.Common.Json;
using Nice.Common.Web.Tree;
using Nice.Common.Web.TreeGrid;
using Nice.Common.Web.TreeView;
using Nice.Domain.Entity.SystemManage;
using Nice.Service.SystemManage;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Areas.SystemManage.Controllers
{
    public class ItemsTypeController : Nice.WebPc.Handler.ControllerBase
    {
        private ItemsService _itemsService = new ItemsService();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            var data = _itemsService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (ItemsBaseEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeJson()
        {
            var data = _itemsService.GetList();
            var treeList = new List<TreeViewModel>();
            foreach (ItemsBaseEntity item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                tree.parentId = item.F_ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson()
        {
            var data = _itemsService.GetList();
            var treeList = new List<TreeGridModel>();
            foreach (ItemsBaseEntity item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                treeModel.id = item.F_Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.F_ParentId;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _itemsService.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ItemsBaseEntity itemsBaseEntity, string keyValue)
        {
            _itemsService.SubmitForm(itemsBaseEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _itemsService.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}

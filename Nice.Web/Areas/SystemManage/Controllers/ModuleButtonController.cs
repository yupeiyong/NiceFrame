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
    public class ModuleButtonController : Nice.WebPc.Handler.ControllerBase
    {
        private ModuleService _moduleService = new ModuleService();
        private ModuleButtonService _moduleButtonService = new ModuleButtonService();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson(string moduleId)
        {
            var data = _moduleButtonService.GetList(moduleId);
            var treeList = new List<TreeSelectModel>();
            foreach (ModuleButtonBaseEntity item in data)
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
        public ActionResult GetTreeGridJson(string moduleId)
        {
            var data = _moduleButtonService.GetList(moduleId);
            var treeList = new List<TreeGridModel>();
            foreach (ModuleButtonBaseEntity item in data)
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
            var data = _moduleButtonService.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ModuleButtonBaseEntity moduleButtonBaseEntity, string keyValue)
        {
            _moduleButtonService.SubmitForm(moduleButtonBaseEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _moduleButtonService.DeleteForm(keyValue);
            return Success("删除成功。");
        }
        [HttpGet]
        public ActionResult CloneButton()
        {
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetCloneButtonTreeJson()
        {
            var moduledata = _moduleService.GetList();
            var buttondata = _moduleButtonService.GetList();
            var treeList = new List<TreeViewModel>();
            foreach (ModuleBaseEntity item in moduledata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = moduledata.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                tree.parentId = item.F_ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                treeList.Add(tree);
            }
            foreach (ModuleButtonBaseEntity item in buttondata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = buttondata.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                if (item.F_ParentId == "0")
                {
                    tree.parentId = item.F_ModuleId;
                }
                else
                {
                    tree.parentId = item.F_ParentId;
                }
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = hasChildren;
                if (item.F_Icon != "")
                {
                    tree.img = item.F_Icon;
                }
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult SubmitCloneButton(string moduleId, string Ids)
        {
            _moduleButtonService.SubmitCloneButton(moduleId, Ids);
            return Success("克隆成功。");
        }
    }
}

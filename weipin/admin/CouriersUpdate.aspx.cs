using System;
using System.Data;
using System.Collections;
using System.Web.Security;

namespace weipin.admin
{
    public partial class CouriersUpdate : Common.BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["txtCourierID"] != null)
            {
                BindCouriers(Convert.ToInt32(Request.Form["txtCourierID"].ToString()));
            }
            else if (Request.Form["txtCourierName"] != null)
            {
                UpdateCouriers();
            }
            else if (Common.Commonality.JudgeNumber(Request.QueryString["cid"], 10))
            {
                BindCouriers(Convert.ToInt32(Request.QueryString["cid"].ToString()));
            }
            else
            {
                Response.Redirect("CouriersList.aspx");
            }
        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="_cid">CourierID</param>
        public void BindCouriers(int _cid)
        {
            BLL.Couriers bc = new weipin.BLL.Couriers();
            Model.Couriers mc = bc.SelectCouriersByID(_cid);
            if (mc.CourierID != 0)
            {
                hidCourierID.Value = mc.CourierID.ToString();
                txtCourierName.Value = mc.CourierName;
                if (mc.CourierSex == true)
                {
                    rdoSexMale.Checked = true;
                }
                else
                {
                    rdoSexWoman.Checked = true;
                }
                hidAreaID.Value = mc.AreaID.ToString();
                txtMobilePhone.Value = mc.MobilePhone;
                if (mc.IsLeft == true)
                {
                    rdoIsLeftYes.Checked = true;
                }
                else
                {
                    rdoIsLeftNo.Checked = true;
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void UpdateCouriers()
        {
            Model.Couriers mc = new weipin.Model.Couriers();
            mc.CourierID = Convert.ToInt16(Request.Form["hidCourierID"].ToString());
            if (Request.Form["txtLoginPassword"].ToString() != "")
            {
                mc.LoginPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtLoginPassword"].ToString(), "MD5");
            }
            else
            {
                mc.LoginPassword = "";
            }
            mc.CourierName = Request.Form["txtCourierName"].ToString().Replace("<", "＜").Replace("&", "＆");
            if (Request.Form["rdoSex"].ToString() == "rdoSexMale")
            {
                mc.CourierSex = true;
            }
            else
            {
                mc.CourierSex = false;
            }
            if (Request.Form["rdoIsLeft"].ToString() == "rdoIsLeftYes")
            {
                mc.IsLeft = true;
            }
            else
            {
                mc.IsLeft = false;
            }
            mc.AreaID = Convert.ToInt32(Request.Form["selArea"].ToString());
            mc.MobilePhone = Request.Form["txtMobilePhone"].ToString();
            BLL.Couriers bc = new weipin.BLL.Couriers();
            if (bc.UpdateCouriers(mc))
            {
                bc.CreateCouriersXML();
                Response.Write("<script>alert('修改成功！');location.href='CouriersList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！');location.href='CouriersList.aspx';</script>");
            }
        }
    }
}
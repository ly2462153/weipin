using System;

namespace weipin.ajaxservice
{
    public partial class MyShippingAddresses : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string value = string.Empty;
                string strParam = Request.Form["ptype"];
                if (strParam != null)
                {
                    switch (strParam)
                    {
                        case "DeleteMyAddress": value = DeleteMyAddress(); break;
                        case "UpdateMyAddressChoose": value = UpdateMyAddressChoose(); break;
                        case "InsertMyAddressChoose": value = InsertMyAddressChoose(); break;
                        case "InsertMyAddress": value = InsertMyAddress(); break;
                    }
                }
                Response.Write(value);
                Response.End();
            }
        }
        /// <summary>
        /// 删除我的地址信息
        /// </summary>
        /// <returns></returns>
        private string DeleteMyAddress()
        {
            string _res = string.Empty;
            int _myaddressid = Convert.ToInt32(Request.Form["adid"].ToString());
            string _loginid = GetSessionOfLoginUser().LoginID;
            BLL.MyShippingAddresses bmsa = new weipin.BLL.MyShippingAddresses();
            return bmsa.DeleteMyShippingAddressesByID(_myaddressid, _loginid).ToString();
        }
        /// <summary>
        /// 修改我的地址信息
        /// </summary>
        /// <returns></returns>
        private string UpdateMyAddressChoose()
        {
            string _res = string.Empty;
            int _oldmainadid = Convert.ToInt32(Request.Form["oldmainadid"].ToString());
            int _newmainadid = Convert.ToInt32(Request.Form["newmainadid"].ToString());
            string _loginid = GetSessionOfLoginUser().LoginID;
            BLL.MyShippingAddresses bmsa = new weipin.BLL.MyShippingAddresses();
            if (bmsa.UpdateMyShippingAddressesChoose(_oldmainadid, _newmainadid, _loginid))
            {
                _res = "1";
            }
            else
            {
                _res = "0";
            }
            return _res;
        }
        /// <summary>
        /// 添加我的地址信息并选中
        /// </summary>
        /// <returns></returns>
        private string InsertMyAddressChoose()
        {
            Model.MyShippingAddresses mmsa = new weipin.Model.MyShippingAddresses();
            mmsa.LoginID = GetSessionOfLoginUser().LoginID;
            mmsa.ConsigneeName = Request.Form["cname"].ToString().Replace("|", "｜");
            mmsa.AreaID = Convert.ToInt32(Request.Form["areaid"].ToString());
            mmsa.MyAddress = Request.Form["address"].ToString().Replace("|", "｜");
            mmsa.MobilePhone = Request.Form["mphone"].ToString().Replace("|", "｜");
            mmsa.Telephone = Request.Form["tphone"].ToString().Replace("|", "｜");
            mmsa.MyZipcode = Request.Form["zipcode"].ToString().Replace("|", "｜");
            mmsa.IsMain = true;
            int _oldmainadid = 0;
            if (Request.Form["oldmainadid"].ToString() != "")
            {
                _oldmainadid = Convert.ToInt32(Request.Form["oldmainadid"].ToString());
            }
            #region 验证
            if (mmsa.ConsigneeName.Length > 5) { return "-1"; }
            if (mmsa.MyAddress.Length > 150) { return "-1"; }
            if (mmsa.MobilePhone.Length > 12) { return "-1"; }
            if (mmsa.Telephone.Length > 15) { return "-1"; }
            if (mmsa.MyZipcode.Length > 6) { return "-1"; }
            #endregion
            BLL.MyShippingAddresses bmsa = new weipin.BLL.MyShippingAddresses();
            return bmsa.InsertMyShippingAddressesChoose(mmsa, _oldmainadid).ToString();
        }
        /// <summary>
        /// 添加我的地址信息
        /// </summary>
        /// <returns></returns>
        private string InsertMyAddress()
        {
            Model.MyShippingAddresses mmsa = new weipin.Model.MyShippingAddresses();
            mmsa.LoginID = GetSessionOfLoginUser().LoginID;
            mmsa.ConsigneeName = Request.Form["cname"].ToString().Replace("|", "｜");
            mmsa.AreaID = Convert.ToInt32(Request.Form["areaid"].ToString());
            mmsa.MyAddress = Request.Form["address"].ToString().Replace("|", "｜");
            mmsa.MobilePhone = Request.Form["mphone"].ToString().Replace("|", "｜");
            mmsa.Telephone = Request.Form["tphone"].ToString().Replace("|", "｜");
            mmsa.MyZipcode = Request.Form["zipcode"].ToString().Replace("|", "｜");
            mmsa.IsMain = false;
            #region 验证
            if (mmsa.ConsigneeName.Length > 5) { return "-1"; }
            if (mmsa.MyAddress.Length > 150) { return "-1"; }
            if (mmsa.MobilePhone.Length > 12) { return "-1"; }
            if (mmsa.Telephone.Length > 15) { return "-1"; }
            if (mmsa.MyZipcode.Length > 6) { return "-1"; }
            #endregion
            BLL.MyShippingAddresses bmsa = new weipin.BLL.MyShippingAddresses();
            return bmsa.InsertMyShippingAddresses(mmsa).ToString();
        }
    }
}
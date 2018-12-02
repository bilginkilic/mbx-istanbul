using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CarShare
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        CARSDBEntities1 myCar;

        [WebMethod]
        public List<Cars> SelectCarInfo(int ID)
        {
            myCar = new CARSDBEntities1();
            if (ID == -1)
                return myCar.Cars.ToList<Cars>();
            else
                return myCar.Cars.Where(s => s.Id == ID).ToList<Cars>();
        }

        [WebMethod]
        public List<Cars> FindNearestCar(int altitude, int latitude, decimal chargePercentage)
        {

            //Uygun araçlar çekilir. (Şarjı senden fazla olanlar)
            List<Cars> suitableCars = SelectCarInfo(-1).Where(s => s.ChargePercent > chargePercentage).ToList<Cars>();
            //İçlerinden en yakını aranır.
            return suitableCars;
        }

        [WebMethod]
        public void UpdateCarInfo(int ID, decimal latitude, decimal longitute, decimal latitudeTarget, decimal longituteTarget)
        {
            //if (latitude == null) latitude = 0;
            //if (longitute == null) longitute = 0;
            //if (latitudeTarget == null) latitudeTarget = 0;
            //if (longituteTarget == null) longituteTarget = 0;

            //Uygun araçlar çekilir. (Şarjı senden fazla olanlar)
            Cars car = SelectCarInfo(ID).First();
            car.Lat = latitude;
            car.Long = latitude;
            car.TargetLat = latitudeTarget;
            car.TargetLong = longituteTarget;
            myCar.SaveChanges();
            //İçlerinden en yakını aranır.
        }

        [WebMethod]
        public void SetCarReserved(int ID, string status)
        {
            Cars car = SelectCarInfo(ID).First();
            car.IsReserved = status;
            myCar.SaveChanges();
            //Set
        }

        [WebMethod]
        public void SetCarPaired(int ID, int IDTarget, string status)
        {
            Cars carSource = SelectCarInfo(ID).First();
            Cars carTarget = SelectCarInfo(IDTarget).First();
            carSource.IsPaired = status;
            carTarget.IsPaired = status;
            myCar.SaveChanges();
            ///Set
        }
    }
}

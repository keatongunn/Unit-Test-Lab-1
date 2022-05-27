using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lab_1_Tests
{
    [TestClass]
    public class UnitTest1
    {
        //Triple A - Arrange, Act, Assert
        [TestMethod]
        public void VehicleAddWorks()
        {
            //Arrange
            int Capacity = 100;            
            VehicleTracker tracker1 = new VehicleTracker(10, "test address 1");
            Vehicle testVehicle = new Vehicle("A01 T22", true);

            //Act
            tracker1.AddVehicle(testVehicle);

            //Assert
            Assert.IsNotNull(tracker1.VehicleList[0]);                                
       }

        [TestMethod]
        public void VehicleAddThrowsException()
        {
            VehicleTracker tracker1 = new VehicleTracker(1, "test address 1");
            Vehicle testVehicle = new Vehicle("A01 T22", true);
            Vehicle testVehicle2 = new Vehicle("XXX YYY", true);
            

            tracker1.AddVehicle(testVehicle);

            Assert.ThrowsException<IndexOutOfRangeException>(() => tracker1.AddVehicle(testVehicle2));
        }

        [TestMethod]
        public void VehicleRemoveMethodWorks()
        {
            int Capacity = 100;
            VehicleTracker tracker1 = new VehicleTracker(10, "test address 1");
            Vehicle testVehicle = new Vehicle("A01 T22", true);
            tracker1.AddVehicle(testVehicle);

            //Act
            tracker1.RemoveVehicle("A01 T22");

            //Assert
            Assert.IsNull(tracker1.VehicleList[0]);
            
        }

        [TestMethod]
        public void VehicleRemoveMethodThrowsException()
        {
            Vehicle testVehicle = new Vehicle("A01 T22", true);
            VehicleTracker tracker1 = new VehicleTracker(10, "test address 1");

            tracker1.AddVehicle(testVehicle);

            Assert.ThrowsException<NullReferenceException>(() => tracker1.RemoveVehicle("XXX YYY ZZZ"));

        }

        [TestMethod]
        public void VehicleTrackerSlotsAvailable()
        {
            //Reworked slots available so it now shows total slots - taken slots, as opposed to just taken slots.
            Vehicle testVehicle = new Vehicle("A01 T22", true);
            VehicleTracker tracker1 = new VehicleTracker(10, "test address 1");

            tracker1.AddVehicle(testVehicle);

            Assert.AreEqual(9, tracker1.SlotsAvailable);
        }


        [TestMethod]
        public void PassholderParkingMethodReturnsListOfPassholders()
        {
            Vehicle testVehicle = new Vehicle("A01 T22", true);
            Vehicle testVehicle2 = new Vehicle("XXX YYY", true);
            Vehicle testVehicle3 = new Vehicle("YYY XXX", false);

            VehicleTracker tracker1 = new VehicleTracker(10, "test address 1");

            tracker1.AddVehicle(testVehicle);
            tracker1.AddVehicle(testVehicle2);
            tracker1.AddVehicle(testVehicle3);

            Assert.AreEqual(2, tracker1.ParkedPassholders().Count);

        }
        [TestMethod]
        public void PercentageOfPassholders()
        {
            Vehicle testVehicle = new Vehicle("A01 T22", true);
            Vehicle testVehicle2 = new Vehicle("XXX YYY", true);
            Vehicle testVehicle3 = new Vehicle("YYY XXX", false);

            VehicleTracker tracker1 = new VehicleTracker(10, "test address 1");

            tracker1.AddVehicle(testVehicle);
            tracker1.AddVehicle(testVehicle2);
            tracker1.AddVehicle(testVehicle3);

            Assert.AreEqual(20, tracker1.PassholderPercentage());
        }

    }
}
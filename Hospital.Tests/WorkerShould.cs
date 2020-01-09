using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hospital.Tests
{
    public class WorkerShould
    {
        [Fact]
        public void CreatePlumberByDefault()
        {
            var factory=new Patient.WorkerFactory();

            #region solution 1
            Patient.Worker worker = factory.Create("nick");
            Assert.IsType<Patient.Plumber>(worker);
            #endregion

            #region solution2  祖父类检测
            Patient.Worker workers = factory.Create("nick", isProgrammer: true);
            Assert.IsAssignableFrom<Patient.Worker>(workers);
            #endregion

            Assert.Throws<ArgumentNullException>(() => factory.Create(null));
        }
    }
}

using Org.BouncyCastle.Tls;
using PharmacySystem.Models;
using PharmacySystem.Repositories.POSBillRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Services
{
    public class POSService
    {
        private readonly IPOSBillRepository _posBillRepository;
        public POSService(string connectionString) 
        {
            _posBillRepository = new POSBillRepository(connectionString);
        }

        public void AddPosBill(decimal receiveAmount, int employeeId)
        {
            try
            {
                _posBillRepository.AddPosBill(receiveAmount, employeeId);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public List<POSBillReport> GetFinancialReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<POSBillReport> reports = _posBillRepository.GetFinancialReport(fromDate, toDate);
                return reports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

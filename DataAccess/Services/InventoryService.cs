using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MosiacData.Entities;
using MosiacData.DBContexts;
using MosiacData.Models;



namespace MosiacData.Services
{
   
    public class InventoryService
    {
        private readonly PurchaseSQLDBContext _db;

        public InventoryService(PurchaseSQLDBContext db)
        {
            _db = db;
        }

        public async Task<List<InventoryDto>> GetAll()
        {
            return await _db.Inventory.Select(p => new InventoryDto
            {
                StockTransactionID = p.StockTransactionID,
                Description = p.Description,
                DateStamp = p.DateStamp.HasValue ? p.DateStamp.Value.ToShortDateString() : string.Empty,
                LineID = p.LineID.HasValue ? p.LineID.Value: 0,
                Location = p.Location,
                OrderReceiptID = p.OrderReceiptID.HasValue ? p.OrderReceiptID.Value : 0,
                PartID = p.PartID.Value > 0 ? p.PartID.Value : 0,
                Qnty = p.Qnty.HasValue ? p.Qnty.Value : 0,
                



            }).ToListAsync();
        }


        public async Task<List<InventoryDto>> GetTransActions(int partID)
        {

            return await _db.Inventory.Where(d => d.PartID==partID).Select(p => new InventoryDto
            {
                StockTransactionID = p.StockTransactionID,
                Description = p.Description,
                DateStamp = p.DateStamp.HasValue ? p.DateStamp.Value.ToShortDateString() : string.Empty,
                LineID = p.LineID.HasValue ? p.LineID.Value : 0,
                Location = p.Location,
                OrderReceiptID = p.OrderReceiptID.HasValue ? p.OrderReceiptID.Value : 0,
                PartID = p.PartID.Value > 0 ? p.PartID.Value : 0,
                Qnty = p.Qnty.HasValue ? p.Qnty.Value : 0,

            }).ToListAsync();


        }

        public async Task<decimal> GetStockLevel(int partID)
        {
            
            return await _db.Inventory.Where(d => d.PartID == partID).SumAsync(r => r.Qnty.Value);
          
           

        }

        public async Task PullPart(int partID, decimal Quantity)
        {
            Inventory _inventory = new Inventory()
            {
                DateStamp = DateTime.Today,
                PartID = partID,
                Qnty = Quantity * -1
            };


            await _db.Inventory.AddAsync(_inventory);
            await _db.SaveChangesAsync();
        }

        public void PushPart(int partID, decimal Quantity)
        {
            Part _part = _db.Part.Find(partID);
            Inventory _inventory = new Inventory();
            if (_part.PartID == partID)
            {
              
                _inventory.DateStamp = DateTime.Today;
                _inventory.TransActionType = 1;
                _inventory.PartID = _part.PartID;
                _inventory.Qnty = Quantity;
                _inventory.UnitOfMeasure = _part.UID.Value;
                _inventory.Description = _part.ItemDescription;

                switch (_inventory.TransActionType)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                     default:
                        break;
                }
                //_inventory.LineID = ;

            }

           _db.Inventory.Add(_inventory);
           _db.SaveChanges();


        }
    }
}

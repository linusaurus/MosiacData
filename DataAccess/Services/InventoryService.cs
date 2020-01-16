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
        private readonly BadgerContext _db;

        public InventoryService(BadgerContext db)
        {
            _db = db;
        }

        public async Task<List<InventoryDto>> GetAll()
        {
            return await _db.Inventory.Select(p => new InventoryDto
            {
                StockTransactionID = p.StockTransactionId,
                Description = p.Description,
                DateStamp = p.DateStamp.HasValue ? p.DateStamp.Value.ToShortDateString() : string.Empty,
                LineID = p.LineId.HasValue ? p.LineId.Value: 0,
                Location = p.Location,
                OrderReceiptID = p.OrderReceiptId.HasValue ? p.OrderReceiptId.Value : 0,
                PartID = p.PartId.Value > 0 ? p.PartId.Value : 0,
                Qnty = p.Qnty.HasValue ? p.Qnty.Value : 0,
                



            }).ToListAsync();
        }


        public async Task<List<InventoryDto>> GetTransActions(int partID)
        {

            return await _db.Inventory.Where(d => d.PartId==partID).Select(p => new InventoryDto
            {
                StockTransactionID = p.StockTransactionId,
                Description = p.Description,
                DateStamp = p.DateStamp.HasValue ? p.DateStamp.Value.ToShortDateString() : string.Empty,
                LineID = p.LineId.HasValue ? p.LineId.Value : 0,
                Location = p.Location,
                OrderReceiptID = p.OrderReceiptId.HasValue ? p.OrderReceiptId.Value : 0,
                PartID = p.PartId.Value > 0 ? p.PartId.Value : 0,
                Qnty = p.Qnty.HasValue ? p.Qnty.Value : 0,

            }).ToListAsync();


        }

        public async Task<decimal> GetStockLevel(int partID)
        {
            
            return await _db.Inventory.Where(d => d.PartId == partID).SumAsync(r => r.Qnty.Value);
          
           

        }

        public async Task PullPart(int partID, decimal Quantity)
        {
            Inventory _inventory = new Inventory()
            {
                DateStamp = DateTime.Today,
                PartId = partID,
                Qnty = Quantity * -1
            };


            await _db.Inventory.AddAsync(_inventory);
            await _db.SaveChangesAsync();
        }

        public void PushPart(int partID, decimal Quantity)
        {
            Part _part = _db.Part.Find(partID);
            Inventory _inventory = new Inventory();
            if (_part.PartId == partID)
            {
              
                _inventory.DateStamp = DateTime.Today;
                _inventory.TransActionType = 1;
                _inventory.PartId = _part.PartId;
                _inventory.Qnty = Quantity;
                _inventory.UnitOfMeasure = _part.Uid.Value;
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

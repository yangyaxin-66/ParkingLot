﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLots> parkingLots;
        public ParkingBoy(List<ParkingLots> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Ticket Park(List<ParkingLots> parkingLots, string car)
        {
            foreach (var lot in parkingLots.Where(lot => lot.HasPosition()))
            {
                return lot.Park(car);
            }

            throw new NoPositionException("No available position.");
        }

        public string Fetch(List<ParkingLots> parkingLots, Ticket ticket)
        {
            var parkingLotWithTicket = parkingLots.FirstOrDefault(lot => lot.HasTicket(ticket));
            if (parkingLotWithTicket == null)
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            return parkingLotWithTicket.Fetch(ticket);
        }
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class ParkingStrategy
    {
        private List<ParkingLots> parkingLots;
        public ParkingStrategy(List<ParkingLots> parkingLots)
        {
            this.parkingLots = parkingLots;
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

        public virtual Ticket Park(List<ParkingLots> parkingLots, string car)
        {
            foreach (var lot in parkingLots.Where(lot => lot.HasPosition()))
            {
                return lot.Park(car);
            }

            throw new NoPositionException("No available position.");
        }
    }
}
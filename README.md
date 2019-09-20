# VehicleParkingWPF

## This is a very simple two-day project as per following description:
Vehicle Parking Slots
This Park has three floors of parking space F1 , F2 and F3. F1 is reserved for two wheelers and is capable of accommodating 10 vehicles each parking slot identified as F1-01 to F1-10. The other two floors are reserved for four wheelers and are capable of accommodating 5 cars each and are identified as F2-01to F2-05, F3-01 to F3-05. 

The application has to function this way:
1. The UI displays the slots in a Floor view format. (Each floor has slots, size of the slot describes the type of the vehicle it can accomodate.)
2. Occupied slots are colored gray.
2. When a vehicle passes into the parking space, 
	- One of the available slots can be chosen.
	- When a slot is clicked, UI will ask for the vehicle number.
3. When a vehicle passes out of the parking space,
	- The slot which was occupied can be clicked.
	- This will show the current status information of the slot.
		- Vehicle number
		- Vehicle Slot Identity
		- Time-in
		- Current time as time-out
		- Total parking occupancy duration
		- Parking fee according to the prefixed duration.
		- Once fee paid shall release the parking slot.
	- The fee can be calculated on a button click. This will set the time-out and fee to be paid.
	- On ok, the slot will be free.

Parking fees details are : Rs 25 for a two-wheeler parking and Rs 50 for a four-wheeler per hour.

#Database Details:
 1. Install pgAdmin4
 2. Create a new database with name "vehiclepark-db"
 3. In this database, restore using file "vehicleparking-postgresql10-db.tar"  


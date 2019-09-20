# VehicleParkingWPF



#This is a very simple two-day project as per following description:
Vehicle Parking Slots
This Park has three floors of parking space F1 , F2 and F3. F1 is reserved for two wheelers and is capable of accommodating 10 vehicles each parking slot identified as F1-01 to F1-10. The other two floors are reserved for four wheelers and are capable of accommodating 5 cars each and are identified as F2-01to F2-05, F3-01 to F3-05. 

The application has to function this way:
 1. When a vehicle passes into the parking space, 
	a. The user interface will be given the vehicle type 

	b. System has to verify the nearest vacant parking slot and if found all full, will provide a message accordingly

	c. If parking slot is available shall display the vacant parking slot Id and the user interface will be provided shall also display time-in and accept the vehicle number.

 2. When a vehicle passes out of the parking space,
	a. The user interface will be given the vehicle number.

	b. The System shall display the vehicle parking details 
		i. Vehicle number
		ii. Vehicle Slot Identity
		iii. Time-in
		iv. Current time as time-out
		v. Total parking occupancy duration
		vi. Parking fee according to the prefixed duration.
		vii. Once fee paid shall release the parking slot.

Parking fees details are : Rs 25 for a two-wheeler parking and Rs 50 for a four-wheeler per hour.



#Database Details:
 1. Install pgAdmin4
 2. Create a new database with name "vehiclepark-db"
 3. In this database, restore using file "vehicleparking-postgresql10-db.tar"  


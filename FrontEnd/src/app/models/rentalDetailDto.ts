export interface RentalDetailDto{
    id:number,
    carId:number,
    customerId:number,
    brand:string,
    modelYear:number,
    dailyPrice:number,
    customerName:string,
    rentDate:Date,
    returnDate:Date
}
export class Address{
    constructor(
        public suite: string,        
        public street: string,        
        public zipcode: string,      
        public city: string,
        public geo?: Geo       
    ) {}
}

export class Geo{
    constructor(
        public lat: string,        
        public lng: string     
    ) {}
}
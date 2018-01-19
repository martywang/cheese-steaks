export class Favorite {
    rating: number;
    review: string;
    user: User;
    store: Store;
}

export class User {
    id: string;
    firstName: string;
    lastName: string;
}

export class Store {
    name: string;
    location: Location;
}

export class Location {
    addressLine1: string;
    addressLine2: string;
    locality: string;
    region: string;
    postalCode: string;
    country: string;
    latitude: number;
    longitude: number;
}
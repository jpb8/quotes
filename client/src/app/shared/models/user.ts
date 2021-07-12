export interface IUser {
    email: string;
    displayName: string;
    token: string;
}

export interface IRegister {
    displayName: string;
    email: string;
    password: string;
    officeId: number[];
}
import { v4 as uuidv4 } from 'uuid';


export interface IUserStoryInProg {
    id: number;
    description: string;
    division: string;
    serviceDiscipline: string;
    discovery: number;
    design: number;
    implementation: number;
    test: number;
    resourceType: string;
}

export interface IFeatureInProg {
    id: number;
    description: string;
    mileStone: string;
    discoveryTotal: number;
    designTotal: number;
    implementationTotal: number;
    testTotal: number;
    userStories: IUserStoryInProg[];
}

export interface IQuoteInProg {
    id: string;
    features: IFeatureInProg[];
}


export class QuoteInProg implements IQuoteInProg {
    id = uuidv4();
    features: IFeatureInProg[] = [];
}

export class FeatureInProg implements IFeatureInProg {
    id = uuidv4();
    description: string;
    mileStone: string;
    discoveryTotal: number;
    designTotal: number;
    implementationTotal: number;
    testTotal: number;
    userStories: IUserStoryInProg[] = [];
}

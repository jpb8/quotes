export interface IUserStory {
    description: string;
    division: string;
    serviceDiscipline: string;
    discovery: number;
    design: number;
    implementation: number;
    test: number;
    resourceType: IResourceType;
    resourceTypeId: number;
    featureId: number;
    id: number;
}

export interface IResourceType {
    name: string;
    rate: number;
    hoursPerWeek: number;
    id: number;
}

export interface IFeature {
    description: string;
    mileStone: string;
    userStories: IUserStory[];
    projectId: number;
    id: number;
}

export interface IProject {
    name: string;
    tigaId: string;
    features: IFeature[];
    id: number;
}

export interface IProjectListItem {
    name: string;
    tigaId: string;
    features: number;
    id: number;
}

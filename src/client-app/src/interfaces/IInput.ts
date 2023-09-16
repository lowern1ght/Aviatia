import {ITitle} from "./ITitle";
import {IPlaceholder} from "./IPlaceholder";

type TypeInput = 'username' | 'password'

export interface IInput extends ITitle, IPlaceholder {
    type : TypeInput | string
}
import {Form, Input} from "antd";
import FormItem from "antd/es/form/FormItem";

import "./styles/LoginPageStyle.css"
import {IInput} from "../interfaces/IInput";

export interface LoginPageProp {
    readonly email: IInput
    readonly password: IInput,
}



const InputForm = (input : IInput, ) => {
    return (
        <div className='_form-item'>
            <p>{input.title}</p>
            <Input
                type={input.type}
                placeholder={input.placeholder}
            />
        </div>
    )
}

export const LoginPage = ({ email, password }: LoginPageProp) => {
    return (
        <div className="_main">
            <Form className="_form">
                <FormItem>
                    <InputForm {...email}/>
                </FormItem>

                <FormItem>
                    <InputForm {...password}/>
                </FormItem>
            </Form>
        </div>
    );
};
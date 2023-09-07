import React from "react";
import {Layout, Typography} from "antd";
import {Content} from "antd/es/layout/layout";

import { Button, Checkbox, Form, Input } from 'antd';
import { LockOutlined, UserOutlined } from '@ant-design/icons';

import "../styles/pages/LoginPage.css"
import backgroundImg from '../assets/bg_sky.jpg'
import {footerText, textStyle} from "../consts";

const contentStyle : React.CSSProperties = {
    backgroundImage: `url(${backgroundImg})`,
    backgroundRepeat: "no-repeat",
    backgroundSize: "cover",
    display: "flex"
}

export const LoginPage = () => {
    return (
        <Layout className="login-page">
            <Content
                style={{
                    ...contentStyle,
                    backdropFilter: "blur(2px)"
                }}
            >
                <div
                    style={{
                        backgroundColor: "white",
                        boxShadow: "-1px 19px 26px 5px rgba(34, 60, 80, 0.2)",
                        borderRadius: 10,
                        padding: "24px",
                        margin: "auto",
                        width: "350px",
                        height: "60%",
                        top: "50%",
                    }}
                >
                    <LoginForm/>
                </div>
            </Content>
        </Layout>
    );
};

const LoginForm = () => {
    const onFinish = (values: never) => {
        console.log('Received values of form: ', values);
    };

    return (
        <Form
            name="normal_login"
            className="login-form"
            initialValues={{ remember: true }}
            onFinish={onFinish}
            style={{height: "100%"}}
        >
            <Form.Item>
                <Typography.Text
                    style={{
                        ...textStyle,
                        fontSize: "16px"
                    }}
                >
                    Sign in
                </Typography.Text>
            </Form.Item>

            <Form.Item
                name="username"
                rules={[{ required: true, message: 'Please input your Username!' }]}
            >
                <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username" />
            </Form.Item>
            <Form.Item
                name="password"
                rules={[{ required: true, message: 'Please input your Password!' }]}
            >
                <Input
                    prefix={<LockOutlined className="site-form-item-icon" />}
                    type="password"
                    placeholder="Password"
                />
            </Form.Item>
            <Form.Item>
                <Form.Item name="remember" valuePropName="checked" noStyle>
                    <Checkbox>Remember me</Checkbox>
                </Form.Item>
            </Form.Item>

            <Form.Item>
                <Button
                    type="primary" htmlType="submit" className="login-form-button"
                    style={{
                        width: "100%"
                    }}
                >
                    Log in
                </Button>
            </Form.Item>

            <Form.Item
                style={{}}
            >
                <Typography.Text
                    style={{
                        margin: "auto",
                        marginBottom: "20px",
                    }}
                >
                    {footerText}
                </Typography.Text>
            </Form.Item>
        </Form>
    )
}
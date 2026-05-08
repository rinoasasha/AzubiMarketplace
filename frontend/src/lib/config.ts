import { env } from "$env/dynamic/public";
import { version as envVersion } from "$app/environment";

export const isDev = env.PUBLIC_NODE_ENV === "development";
export const defaultHost = env.PUBLIC_DEFAULT_HOST ?? "localhost";
export const apiBaseUrl = env.PUBLIC_API_BASE_URL ?? ("http://localhost:5000");
export const fallbackReturnUrl = env.PUBLIC_FALLBACK_RETURN_URL ?? "http://localhost:5173";
export const withCredentials = env.PUBLIC_WITH_CREDENTIALS ? true : isDev;
export const version = envVersion ?? "0.0.0";
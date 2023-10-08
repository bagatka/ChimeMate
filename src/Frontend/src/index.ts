import { WebApp, Telegram } from "@twa-dev/types";

const telegramWindow = window as unknown as Window & { Telegram: Telegram };

const WebApp: WebApp = telegramWindow.Telegram.WebApp;

WebApp.ready();
WebApp.MainButton.hide();
WebApp.showAlert('Hey there!');

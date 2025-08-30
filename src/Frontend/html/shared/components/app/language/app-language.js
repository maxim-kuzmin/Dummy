customElements.define(
  "app-language",
  class extends HTMLElement {
    constructor() {
      super();

      this.handleMenuItemClick = this.handleMenuItemClick.bind(this);
      this.handleWindowClick = this.handleWindowClick.bind(this);
    }

    getButtonElement() {
      return app.component.getElement.call(this, "button");
    }

    getMenuElement() {
      return app.component.getElement.call(this, "ul");
    }

    getMenuItemElements() {
      return app.component.getElements.call(this, "ul li");
    }

    handleMenuItemClick(e) {
      const buttonElement = this.getButtonElement();
      const menuItemElements = this.getMenuItemElements();

      for (const menuItemElement of menuItemElements) {
        if (menuItemElement === e.currentTarget) {
          app.selection.on.call(menuItemElement);

          for (const childElement of menuItemElement.children) {
            buttonElement.innerText = childElement.innerText;
            break;
          }
        } else {
          app.selection.off.call(menuItemElement);
        }
      }
    }

    handleWindowClick(e) {
      const buttonElement = this.getButtonElement();
      const menuElement = this.getMenuElement();

      if (e.target === buttonElement) {
        app.visibility.toggle.call(menuElement);
      } else if (e.target !== menuElement) {
        app.visibility.off.call(menuElement);
      }
    }

    connectedCallback() {
      app.component.render.call(this, "#tpl-app-language");

      const menuItemElements = this.getMenuItemElements();

      for (const menuItemElement of menuItemElements) {
        menuItemElement.addEventListener("click", this.handleMenuItemClick);
      }

      if (globalThis.addEventListener) {
        globalThis.addEventListener("click", this.handleWindowClick);
      }
    }

    disconnectedCallback() {
      if (globalThis.removeEventListener) {
        globalThis.removeEventListener("click", this.handleWindowClick);
      }
    }
  }
);

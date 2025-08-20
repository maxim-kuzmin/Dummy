customElements.define(
  "app-nav",
  class extends HTMLElement {
    constructor() {
      super();

      this.handleMenuItemClick = this.handleMenuItemClick.bind(this);
    }

    getMenuElement() {
      return app.component.getElement.call(this, "ul");
    }

    getMenuItemElements() {
      return app.component.getElements.call(this, "ul li");
    }

    handleMenuItemClick(e) {
      e.stopPropagation();

      const menuItemElements = this.getMenuItemElements();

      for (const menuItemElement of menuItemElements) {
        if (menuItemElement === e.currentTarget) {
          app.selection.on.call(menuItemElement);
        } else {
          app.selection.off.call(menuItemElement);
        }
      }
    }

    connectedCallback() {
      app.component.render.call(this, "#tpl-app-nav");

      const menuItemElements = this.getMenuItemElements();

      for (const menuItemElement of menuItemElements) {
        menuItemElement.addEventListener("click", this.handleMenuItemClick);
      }
    }
  }
);

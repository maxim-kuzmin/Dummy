customElements.define('app-footer', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    app.component.render.call(this, '#tpl-app-footer');
  }
});
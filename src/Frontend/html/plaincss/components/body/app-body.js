customElements.define('app-body', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.attachShadow({ mode: 'open' }).append(document.querySelector('#tpl-app-body').content.cloneNode(true));
  }
});
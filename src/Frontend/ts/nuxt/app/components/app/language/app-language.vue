<script setup lang="ts">
  import type { CSSProperties } from 'vue'
  import type { Language } from './app-language.types'

  const _this = (function(
    switchLocalePath,
    i18n,
    buttonElementRef,
    menuElementRef,
    isMenuOpen) {
    const { locale, locales} = i18n;

    function handleWindowClick(ev: MouseEvent): void {
      const buttonElement = _this.buttonElementRef.value
      const menuElement = _this.menuElementRef.value

      if (!buttonElement || !menuElement) {
        return
      }

      if (ev.target === buttonElement) {
        _this.isMenuOpen.value = !_this.isMenuOpen.value
      } else if (ev.target !== menuElement) {
        _this.isMenuOpen.value = false
      }
    }

    return {
      switchLocalePath,
      locale,
      locales,
      buttonElementRef,
      menuElementRef,
      isMenuOpen,
      handleWindowClick
    }
  })(
    useSwitchLocalePath(),
    useI18n(),
    useTemplateRef('button'),
    useTemplateRef('menu'),
    ref(false))

  const currentLanguageName = computed(
    () => _this.locales.value.find((locale) => locale.code === _this.locale.value)?.name,
  )

  const languages = computed(() =>
    _this.locales.value.map(
      (locale) =>
        ({
          code: locale.code,
          name: locale.name,
          url: _this.switchLocalePath(locale.code),
          selected: locale.code === _this.locale.value,
        }) as Language,
    ),
  )

  const menuStyle = computed(
    () =>
      ({
        visibility: _this.isMenuOpen.value ? 'visible' : 'hidden',
      }) as CSSProperties,
  )

  onMounted(() => {
    if (globalThis.addEventListener) {
      globalThis.addEventListener('click', _this.handleWindowClick)
    }
  })

  onUnmounted(() => {
    if (globalThis.removeEventListener) {
      globalThis.removeEventListener('click', _this.handleWindowClick)
    }
  })
</script>

<template>
  <nav class="app-language">
    <button ref="button" type="button">
      {{ currentLanguageName }}
    </button>
    <ul ref="menu" :style="menuStyle">
      <li
        v-for="language in languages"
        :key="language.code"
        :data-selected="language.selected || null"
      >
        <NuxtLink :to="language.url">{{ language.name }}</NuxtLink>
      </li>
    </ul>
  </nav>
</template>

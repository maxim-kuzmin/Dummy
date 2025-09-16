<script setup lang="ts">
  import type { CSSProperties } from 'vue'
  import type { AppLanguageComponentData, AppLanguageComponentItem } from '~/utils/app/components/language/app-language-component.types'

  const _this = (function (
    switchLocalePath,
    i18n,
    buttonElementRef,
    menuElementRef
  ) {
    const isMenuOpen = ref(false)

    const data = {
      currentLanguageName: computed(
        () =>
          i18n.locales.value.find((locale) => locale.code === i18n.locale.value)
            ?.name,
      ),
      items: computed(() =>
        i18n.locales.value.map(
          (locale) =>
            ({
              code: locale.code,
              name: locale.name,
              url: switchLocalePath(locale.code),
              selected: locale.code === i18n.locale.value,
            }) as AppLanguageComponentItem,
        ),
      ),
      menuStyle: computed(
        () =>
          ({
            visibility: isMenuOpen.value ? 'visible' : 'hidden',
          }) as CSSProperties,
      ),
    } as AppLanguageComponentData

    function handleWindowClick(ev: MouseEvent): void {
      const buttonElement = buttonElementRef.value
      const menuElement = menuElementRef.value

      if (!buttonElement || !menuElement) {
        return
      }

      if (ev.target === buttonElement) {
        isMenuOpen.value = !isMenuOpen.value
      } else if (ev.target !== menuElement) {
        isMenuOpen.value = false
      }
    }

    return {
      data,
      onMounted() {
        if (globalThis.addEventListener) {
          globalThis.addEventListener('click', handleWindowClick)
        }
      },
      onUnmounted() {
        if (globalThis.removeEventListener) {
          globalThis.removeEventListener('click', handleWindowClick)
        }
      },
    }
  })(
    useSwitchLocalePath(),
    useI18n(),
    useTemplateRef('button'),
    useTemplateRef('menu')
  )

  onMounted(_this.onMounted)
  onUnmounted(_this.onUnmounted)

  const currentLanguageName = _this.data.currentLanguageName
  const items = _this.data.items
  const menuStyle = _this.data.menuStyle
</script>

<template>
  <nav class="app-language">
    <button ref="button" type="button">
      {{ currentLanguageName }}
    </button>
    <ul ref="menu" :style="menuStyle">
      <li
        v-for="item in items"
        :key="item.code"
        :data-selected="item.selected || null"
      >
        <NuxtLink :to="item.url">{{ item.name }}</NuxtLink>
      </li>
    </ul>
  </nav>
</template>

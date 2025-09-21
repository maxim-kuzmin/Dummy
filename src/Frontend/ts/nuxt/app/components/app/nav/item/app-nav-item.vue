<script setup lang="ts">
  import type { AppNavComponentItem } from '~/utils/domain/app/components/nav/app-nav-component.types'
  import type { AppNavItemComponentInput } from '~/utils/domain/app/components/nav/item/app-nav-item-component.types'
  import type { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types'

  const props = defineProps<AppNavItemComponentInput>()

  const { item } = props

  function createItemsComponentInput(
    item: AppNavComponentItem,
  ): AppNavItemsComponentInput {
    return {
      items: ref(item.children),
    }
  }
</script>

<template>
  <NuxtLink :to="item.url">{{ item.text }}</NuxtLink>
  <AppNavItems
    v-if="item.children.length > 0"
    v-bind="createItemsComponentInput(item)"
  />
</template>
